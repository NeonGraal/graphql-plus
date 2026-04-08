//HintName: test_generic-parent-enum-dom+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Output;

public interface ItestGnrcPrntEnumDomOutp
  : ItestFieldGnrcPrntEnumDomOutp<ItestDomGnrcPrntEnumDomOutp>
{
  ItestGnrcPrntEnumDomOutpObject? As_GnrcPrntEnumDomOutp { get; }
}

public interface ItestGnrcPrntEnumDomOutpObject
  : ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>
{
}

public interface ItestFieldGnrcPrntEnumDomOutp<TRef>
  // No Base because it's Class
{
  ItestFieldGnrcPrntEnumDomOutpObject<TRef>? As_FieldGnrcPrntEnumDomOutp { get; }
}

public interface ItestFieldGnrcPrntEnumDomOutpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumDomOutp
{
  gnrcPrntEnumDomOutpLabel,
  gnrcPrntEnumDomOutpOther,
}

public interface ItestDomGnrcPrntEnumDomOutp
  : IGqlpDomainEnum
{
}
