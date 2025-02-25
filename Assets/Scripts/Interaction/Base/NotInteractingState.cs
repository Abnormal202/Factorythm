﻿public class NotInteractingState : InteractableState {
    private bool _zWasPressed;

    public Interactable PCOnInteractable() {
        return MyStateMachine.CurInput.PC.OnInteractable();
    }

    public override void SetZPressed(bool zPressed) {
        if ((!_zWasPressed && zPressed) && PCOnInteractable()) {
            MyStateMachine.CurInput.CurInteractable = PCOnInteractable();
            MyStateMachine.Transition<InteractingState>();
        }

        _zWasPressed = zPressed;
    }

    public override void Move() {
    }

    public override void Enter(InteractableStateInput i) {
        Interactable ci = MyStateMachine.CurInput.CurInteractable;
        ci.OnDeInteract(MyStateMachine.CurInput.PC);
        MyStateMachine.CurInput.CurInteractable = null;
    }

    public override void Exit(InteractableStateInput i) {
        
    }

    public override void Update(InteractableStateInput i) {
    }
}