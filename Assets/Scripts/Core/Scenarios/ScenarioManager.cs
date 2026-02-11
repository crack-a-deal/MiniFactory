using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    [SerializeField] private ScenarioData config;
    [SerializeField] private PumpDevice pump;
    [SerializeField] private List<BaseDevice> devices;
    [SerializeField] private Text label;

    private DeviceRegistry _deviceRegistry;
    private ScenarioBuilder _builder;

    private ScenarioStep _currentStep;
    private int _currentStepIndex=0;
    private void Awake()
    {
        _deviceRegistry = new DeviceRegistry(devices);
        _builder = new ScenarioBuilder(_deviceRegistry);
    }

    private void Start()
    {
        BuildAndStartStep();
    }

    private void Update()
    {
        float dt = Time.deltaTime;
        if (_currentStep != null)
        {
            _currentStep.Tick(dt);
        }

        if (_currentStep.State != StepState.Active)
        {
            _currentStepIndex++;
            if (_currentStepIndex >= config.Steps.Count)
            {
                label.text = "Scenario compete";
                return;
            }

            BuildAndStartStep();
        }
    }

    private void BuildAndStartStep()
    {
        StepData stepData = config.Steps[_currentStepIndex];
        _currentStep = _builder.BuildStep(stepData);
        _currentStep.Activate();

        label.text = stepData.Description;
    }
}
