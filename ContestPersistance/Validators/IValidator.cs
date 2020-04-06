using ContestModel.Domain;

namespace ContestPersistance.Validators
{
    public interface IValidator<ID, E> where E : Entity<ID>
    {
        void Validate(E entity);

    }
}
