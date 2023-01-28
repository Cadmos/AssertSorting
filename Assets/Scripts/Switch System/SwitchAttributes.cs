public enum SwitchType
{
    NoType,
    Button,
    Switch,
    Rocker,
    Rotary,
    Slide,
    Tactile,
    Key
}

public enum SwitchToggle
{
    NotInitialized,
    Toggle,
    NoToggle
}

public enum SwitchControlType
{
    NoType,
    Manual,
    Mixed,
    Automatic
}

public enum SwitchSignalType
{
    NoType,
    Analog,
    Digital
}

public enum SwitchState
{
    NoState,
    On,
    Off,
    Transitioning,
    Broken
}

public enum SwitchLight
{
    NotInitialized,
    NoLight,
    LightOnWhenActivated,
    LightAlwaysOn
}