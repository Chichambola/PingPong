using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Predictor : MonoBehaviour
{
    [SerializeField] private Rigidbody _ball;
    [SerializeField] private GameObject _table;
    
    [Header("Simulation settings")]
    [SerializeField] private float _step = 0.02f;
    [SerializeField] private int _count = 50;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private Transform _phantomPrefab;
    
    private Scene _scene;
    private PhysicsScene _simulationScene;
    private Rigidbody _simulationBody;

    public void Prepare()
    {
        _scene = SceneManager.CreateScene("Physics simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        _simulationScene = _scene.GetPhysicsScene();
        
        _simulationBody = Instantiate(_ball);
        _simulationBody.GetComponent<MeshRenderer>().enabled = false;
        SceneManager.MoveGameObjectToScene(_simulationBody.gameObject, _scene);
        
        var table = Instantiate(_table, _table.transform.position, _table.transform.rotation);
        table.GetComponent<MeshRenderer>().enabled = false;
        SceneManager.MoveGameObjectToScene(table, _scene);
    }

    public Vector3 Predict(bool isPlayerSide, out float time)
    {
        Vector3 finalPosition = Vector3.zero;
        
        time = 0;
        
        _simulationBody.transform.position = _ball.transform.position;
        _simulationBody.velocity = _ball.velocity;
        
        for (int i = 0; i < _count; i++)
        {
            _simulationScene.Simulate(_step);
            time += _step;
            Instantiate(_phantomPrefab, _simulationBody.position, Quaternion.identity);
            
            
            if (_simulationBody.position.z < _endPoint.position.z)
            {
                finalPosition = _simulationBody.position;
                
                break;
            }
        }
        
        return finalPosition;
    }

    private void OnDrawGizmos()
    {
        if(_endPoint == null)
            return;
        
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(_endPoint.position, 0.1f);
    }
}
