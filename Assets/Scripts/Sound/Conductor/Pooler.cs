﻿using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Pooler : MonoBehaviour {
    public GameObject ConveyorBelt;
    public GameObject OutputPort;
    public GameObject InputPort;
    
    public MachineBluePrint ConveyorBluePrint;
    
    public List<Machine> AllMachines { get; private set; }

    void Start() {
        AllMachines = new List<Machine>(FindObjectsOfType<Machine>());
    }

    public Machine InstantiateMachine(GameObject copy, Vector2 newPos, Quaternion rotation) {
        Machine newMachine = Instantiate(
            copy, 
            new Vector3(newPos.x, newPos.y, copy.transform.position.z),
            rotation
        ).GetComponent<Machine>();
        
        AllMachines.Add(newMachine);
        return newMachine;
    }
    
    //For some reason c# wouldn't let me do default arguments so I just had to overload this one
    public Machine InstantiateMachine(GameObject copy, Vector2 newPos) {
        return InstantiateMachine(copy, newPos, Quaternion.identity); // Quaternion.identity means no rotation
    }

    public Machine InstantiateConveyor(Vector2 newPos, Quaternion direction) {
        return InstantiateMachine(ConveyorBelt, newPos, direction);
    }

    public OutputPort InstantiateOutputPort(Vector3 newPos, Transform parent) {
        return Instantiate(OutputPort, newPos, transform.rotation, parent).GetComponent<OutputPort>();
    }
    
    public InputPort InstantiateInputPort(Vector3 newPos, Transform parent) {
        return Instantiate(InputPort, newPos, transform.rotation, parent).GetComponent<InputPort>();
    }

    public MachineBluePrint CreateConveyorBluePrint(Vector3 pos, Quaternion rot) {
        return Instantiate(ConveyorBluePrint, pos, rot);
    }

    public MachineBluePrint CreateMachineBluePrint(GameObject m, Vector2 pos) {
        Vector3 instantiatePos = new Vector3(pos.x, pos.y, m.transform.position.z);
        return Instantiate(m, instantiatePos, Quaternion.identity).GetComponent<MachineBluePrint>();
    }
}