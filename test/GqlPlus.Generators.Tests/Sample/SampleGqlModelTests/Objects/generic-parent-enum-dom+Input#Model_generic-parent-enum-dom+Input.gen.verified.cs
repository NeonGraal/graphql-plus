//HintName: Model_generic-parent-enum-dom+Input.gen.cs
// Generated from generic-parent-enum-dom+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_enum_dom_Input;

public interface IGnrcPrntEnumDomInp
  : IFieldGnrcPrntEnumDomInp
{
}
public class InputGnrcPrntEnumDomInp
  : InputFieldGnrcPrntEnumDomInp
  , IGnrcPrntEnumDomInp
{
}

public interface IFieldGnrcPrntEnumDomInp<Tref>
{
  Tref field { get; }
}
public class InputFieldGnrcPrntEnumDomInp<Tref>
  : IFieldGnrcPrntEnumDomInp<Tref>
{
  public Tref field { get; set; }
}

public enum EnumGnrcPrntEnumDomInp
{
  gnrcPrntEnumDomInpLabel,
  gnrcPrntEnumDomInpOther,
}

public interface IDomGnrcPrntEnumDomInp
{
}
public class DomainDomGnrcPrntEnumDomInp
  : IDomGnrcPrntEnumDomInp
{
}
