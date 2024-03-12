public interface IPhysicsLawHandler
{
    void OnLawsUpdate(LawEnum[] newLaws);
    LawEnum MyLaw { get; }
}