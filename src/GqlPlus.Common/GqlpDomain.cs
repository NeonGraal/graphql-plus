namespace GqlPlus;

public interface IGqlpDomain<T>
{
  T? Value { get; }
  void SetValue(T? value);
}

public interface IGqlpDomainBoolean : IGqlpDomain<bool>;

public interface IGqlpDomainEnum : IGqlpDomain<uint>;

public interface IGqlpDomainNumber : IGqlpDomain<decimal>;

public interface IGqlpDomainString : IGqlpDomain<string>;

public class GqlpDomain<T>
{
  public T? Value { get; private set; }
  public void SetValue(T? value) => Value = value;
}

public class GqlpDomainBoolean : GqlpDomain<bool>, IGqlpDomain<bool>;

public class GqlpDomainEnum : GqlpDomain<uint>, IGqlpDomain<uint>;

public class GqlpDomainNumber : GqlpDomain<decimal>, IGqlpDomain<decimal>;

public class GqlpDomainString : GqlpDomain<string>, IGqlpDomain<string>;
