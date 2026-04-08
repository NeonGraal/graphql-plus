//HintName: test_generic-parent-enum-dom+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

public interface ItestGnrcPrntEnumDomDual
  : ItestFieldGnrcPrntEnumDomDual<ItestDomGnrcPrntEnumDomDual>
{
  ItestGnrcPrntEnumDomDualObject? As_GnrcPrntEnumDomDual { get; }
}

public interface ItestGnrcPrntEnumDomDualObject
  : ItestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>
{
}

public interface ItestFieldGnrcPrntEnumDomDual<TRef>
  // No Base because it's Class
{
  ItestFieldGnrcPrntEnumDomDualObject<TRef>? As_FieldGnrcPrntEnumDomDual { get; }
}

public interface ItestFieldGnrcPrntEnumDomDualObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumDomDual
{
  gnrcPrntEnumDomDualLabel,
  gnrcPrntEnumDomDualOther,
}

public interface ItestDomGnrcPrntEnumDomDual
  : IGqlpDomainEnum
{
}
