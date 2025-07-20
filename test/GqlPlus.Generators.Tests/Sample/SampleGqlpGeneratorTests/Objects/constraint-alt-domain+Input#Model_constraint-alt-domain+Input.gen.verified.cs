//HintName: Model_constraint-alt-domain+Input.gen.cs
// Generated from constraint-alt-domain+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_constraint_alt_domain_Input;

public interface ICnstAltDmnInp
{
  RefCnstAltDmnInp<DomCnstAltDmnInp> AsRefCnstAltDmnInp { get; }
}
public class InputCnstAltDmnInp
  : ICnstAltDmnInp
{
  public RefCnstAltDmnInp<DomCnstAltDmnInp> AsRefCnstAltDmnInp { get; set; }
}

public interface IRefCnstAltDmnInp<Tref>
{
  Tref Asref { get; }
}
public class InputRefCnstAltDmnInp<Tref>
  : IRefCnstAltDmnInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IDomCnstAltDmnInp
{
}
public class DomainDomCnstAltDmnInp
  : IDomCnstAltDmnInp
{
}
