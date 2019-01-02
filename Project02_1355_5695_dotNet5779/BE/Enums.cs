namespace BE
{
    public enum Gender
    {
        Male, Female
    }
    public enum CarType
    {
        Private, TwoWheels, MediumTruck, HeavyTruck
    }
    public enum GearType
    {
        Automatic, Manual
    }

    public enum Pass
    {
        Passed, Failed, None
    }

    public enum TestCriterion
    {
        Distance, Reverse, Mirrors, Signals
    }

    public enum TzStatus
    {
        R_NOT_VALID = -2, R_ELEGAL_INPUT = -1, R_VALID = 1
    };
}
