namespace GqlPlus;

public interface IGqlpDomain<T>
{
  T Value { get; }
  void SetValue(T value);
}

public interface IGqlpDomainBoolean : IGqlpDomain<bool>;

public interface IGqlpDomainEnum : IGqlpDomain<uint>;

public interface IGqlpDomainNumber : IGqlpDomain<decimal>;

public interface IGqlpDomainString : IGqlpDomain<string>;
