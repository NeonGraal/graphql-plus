//HintName: test_generic-parent-enum-dom+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Input;

public interface ItestGnrcPrntEnumDomInp
  : ItestFieldGnrcPrntEnumDomInp<ItestDomGnrcPrntEnumDomInp>
{
  ItestGnrcPrntEnumDomInpObject? As_GnrcPrntEnumDomInp { get; }
}

public interface ItestGnrcPrntEnumDomInpObject
  : ItestFieldGnrcPrntEnumDomInpObject<ItestDomGnrcPrntEnumDomInp>
{
}

public interface ItestFieldGnrcPrntEnumDomInp<TRef>
  // No Base because it's Class
{
  ItestFieldGnrcPrntEnumDomInpObject<TRef>? As_FieldGnrcPrntEnumDomInp { get; }
}

public interface ItestFieldGnrcPrntEnumDomInpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumDomInp
{
  gnrcPrntEnumDomInpLabel,
  gnrcPrntEnumDomInpOther,
}

public interface ItestDomGnrcPrntEnumDomInp
  : IGqlpDomainEnum
{
}
