//HintName: Model_constraint-field-domain+Input.gen.cs
// Generated from constraint-field-domain+Input.graphql+

/*
*/

namespace GqlTest.Model_constraint_field_domain_Input;

public interface ICnstFieldDmnInp
  : IRefCnstFieldDmnInp
{
}
public class InputCnstFieldDmnInp
  : InputRefCnstFieldDmnInp
  , ICnstFieldDmnInp
{
}

public interface IRefCnstFieldDmnInp<Tref>
{
  Tref field { get; }
}
public class InputRefCnstFieldDmnInp<Tref>
  : IRefCnstFieldDmnInp<Tref>
{
  public Tref field { get; set; }
}

public interface IDomCnstFieldDmnInp
{
}
public class DomainDomCnstFieldDmnInp
  : IDomCnstFieldDmnInp
{
}
