public interface IProcessFactory
{
    public WagePaymentProcess CreateWagePaymentProcess();
    public DismissalProcess CreateDismissalProcess();
    public AdmissionalProcess CreateAdmissionalProcess();
}