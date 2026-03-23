namespace GqlPlus;

public interface IGqlpDomainBase<T>
{
  T? Value { get; }
  void SetValue(T? value);
}

public interface IGqlpDomainBoolean : IGqlpDomainBase<bool>
{ }

public interface IGqlpDomainEnum : IGqlpDomainBase<uint>
{ }

public interface IGqlpDomainNumber : IGqlpDomainBase<decimal>
{ }

public interface IGqlpDomainString : IGqlpDomainBase<string>
{ }

public class GqlpDomainBase<T>
{
  public T? Value { get; private set; }
  public void SetValue(T? value) => Value = value;
}

public class GqlpDomainBoolean : GqlpDomainBase<bool>, IGqlpDomainBoolean
{ }

public class GqlpDomainEnum : GqlpDomainBase<uint>, IGqlpDomainBase<uint>
{ }

public class GqlpDomainNumber : GqlpDomainBase<decimal>, IGqlpDomainNumber
{ }

public class GqlpDomainString : GqlpDomainBase<string>, IGqlpDomainString
{ }
