//HintName: Model_generic-parent-enum-dom+Dual.gen.cs
// Generated from generic-parent-enum-dom+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_enum_dom_Dual;

public interface IGnrcPrntEnumDomDual
  : IFieldGnrcPrntEnumDomDual
{
}
public class DualGnrcPrntEnumDomDual
  : DualFieldGnrcPrntEnumDomDual
  , IGnrcPrntEnumDomDual
{
}

public interface IFieldGnrcPrntEnumDomDual<Tref>
{
  Tref field { get; }
}
public class DualFieldGnrcPrntEnumDomDual<Tref>
  : IFieldGnrcPrntEnumDomDual<Tref>
{
  public Tref field { get; set; }
}

public enum EnumGnrcPrntEnumDomDual
{
  gnrcPrntEnumDomDualLabel,
  gnrcPrntEnumDomDualOther,
}

public interface IDomGnrcPrntEnumDomDual
{
}
public class DomainDomGnrcPrntEnumDomDual
  : IDomGnrcPrntEnumDomDual
{
}
