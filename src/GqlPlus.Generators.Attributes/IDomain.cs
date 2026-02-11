namespace GqlPlus;

public interface IDomain<T>
{
  T Value { get; }
  void SetValue(T value);
}

public interface IDomainBoolean : IDomain<bool>;

public interface IDomainEnum : IDomain<uint>;

public interface IDomainNumber : IDomain<decimal>;

public interface IDomainString : IDomain<string>;
