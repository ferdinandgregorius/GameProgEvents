using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Unity.VisualScripting;

public class StartupComponent : MonoBehaviour
{
    [SerializeField]
    private float timeBeforeGameStartInSeconds = 5f;
    
    // private ObstacleFactory obstacleFactory;
    // private SphereFactory sphereFactory;
    private SphereComponent sphereComponent;
    private List<ObstacleComponents> obstacleComponents = new List<ObstacleComponents>();
    private ObstacleComponents obstacleComponent;
    private ScoreCounterComponent scoreCounterComponent;
    private PlaneComponent planeComponent;
    

    // Start is called before the first frame update
    void Start()
    {
        var obstacleFactory = new ObstacleFactory();
        var sphereFactory = new SphereFactory();
        var scoreCounterFactory = new ScoreCounterFactory();
        var planeFactory = new PlaneFactory();

        this.sphereComponent = sphereFactory.CreateSphere(new Vector3(0, 4,0), false);
        this.obstacleComponents.Add(obstacleFactory.CreateObstacle(new Vector3(0, 2,0)));
        this.obstacleComponents.Add(obstacleFactory.CreateObstacle(new Vector3(0, 0,0)));
        this.obstacleComponents.Add(obstacleFactory.CreateObstacle(new Vector3(0, -2,0)));
        this.scoreCounterComponent = scoreCounterFactory.CreateScoreCounter();
        this.planeComponent = planeFactory.CreatePlane(new Vector3(0, -4, 0));
        
        this.RegisterEvents();

        this.StartCoroutine("StartGameAfterSeconds", this.timeBeforeGameStartInSeconds);
    }

    private void RegisterEvents()
    {
        this.obstacleComponents.ForEach(component =>
        {
            component.OnObstacleCollidedObservable.Subscribe((_) =>
            {
                this.scoreCounterComponent.Increase();
            });
            
            component.OnObstacleColorObservable.Subscribe((_) =>
            {
                component.CollisionChangeColor();
            });
        });

        this.planeComponent.onPlaneCollisionObservable.Subscribe((_) =>
        {
            this.planeComponent.OnCollisionEnter();
        });
    }

    IEnumerator StartGameAfterSeconds(float timeInSeconds)
    {
        yield return new WaitForSecondsRealtime(timeInSeconds);
        this.sphereComponent.EnableGravity();
    }
}
