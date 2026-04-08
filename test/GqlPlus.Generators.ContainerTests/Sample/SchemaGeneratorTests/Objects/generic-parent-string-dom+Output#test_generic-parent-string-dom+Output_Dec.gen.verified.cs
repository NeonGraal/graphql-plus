//HintName: test_generic-parent-string-dom+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Output;

public interface ItestGnrcPrntStrDomOutp
  : ItestFieldGnrcPrntStrDomOutp<ItestDomGnrcPrntStrDomOutp>
{
  ItestGnrcPrntStrDomOutpObject? As_GnrcPrntStrDomOutp { get; }
}

public interface ItestGnrcPrntStrDomOutpObject
  : ItestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>
{
}

public interface ItestFieldGnrcPrntStrDomOutp<TRef>
  // No Base because it's Class
{
  ItestFieldGnrcPrntStrDomOutpObject<TRef>? As_FieldGnrcPrntStrDomOutp { get; }
}

public interface ItestFieldGnrcPrntStrDomOutpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntStrDomOutp
  : IGqlpDomainString
{
}
