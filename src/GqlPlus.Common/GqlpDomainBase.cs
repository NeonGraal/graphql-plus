namespace GqlPlus;

public interface IGqlpDomainBase<TDomain>
{
  TDomain? Value { get; }
  T? ValueAs<T>();
  void SetValue(TDomain? value);
}

public interface IGqlpDomainBoolean : IGqlpDomainBase<bool>
{ }

public interface IGqlpDomainEnum : IGqlpDomainBase<uint>
{ }

public interface IGqlpDomainNumber : IGqlpDomainBase<decimal>
{ }

public interface IGqlpDomainString : IGqlpDomainBase<string>
{ }

public class GqlpDomainBase<TDomain>
{
  public TDomain? Value { get; private set; }
  public virtual T? ValueAs<T>() => Value is T value ? value : default;
  public void SetValue(TDomain? value) => Value = value;
}

public class GqlpDomainBoolean : GqlpDomainBase<bool>, IGqlpDomainBoolean
{ }

public class GqlpDomainEnum : GqlpDomainBase<uint>, IGqlpDomainBase<uint>
{ }

public class GqlpDomainNumber : GqlpDomainBase<decimal>, IGqlpDomainNumber
{ }

public class GqlpDomainString : GqlpDomainBase<string>, IGqlpDomainString
{ }
