public class UnitedStatesDismissalProcess : DismissalProcess
{
    public override string Title => "Employee Dismissal";
    public override void Apply(DismissalArgs args)
    {
        args.Company.Money -= 4 * args.Employe.Wage;
    }
}
public class UnitedStatesWagePaymentProcess : WagePaymentProcess
{
    public override string Title => "Salary Payment";
    public override void Apply(WagePaymentArgs args)
    {
        args.Company.Money -= 1.55m * args.Employe.Wage + 400;
    }
}
public class UnitedStatesAdmissionalProcess : AdmissionalProcess
{
    public override string Title => "Employee Admissional";

    public override void Hire(AdmissionalArgs args)
    {
        args.Company.Money -= args.Employe.Wage;
        args.Employe.WorkSchedule = 12;
    }
}

public class UnitedStatesProcessFactory : IProcessFactory
{
    public DismissalProcess CreateDismissalProcess()
    => new UnitedStatesDismissalProcess();
    public WagePaymentProcess CreateWagePaymentProcess()
    => new UnitedStatesWagePaymentProcess();
    public AdmissionalProcess CreateAdmissionalProcess()
    => new UnitedStatesAdmissionalProcess();
}
