//HintName: test_generic-parent-string-dom+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Input;

public interface ItestGnrcPrntStrDomInp
  : ItestFieldGnrcPrntStrDomInp<ItestDomGnrcPrntStrDomInp>
{
  ItestGnrcPrntStrDomInpObject? As_GnrcPrntStrDomInp { get; }
}

public interface ItestGnrcPrntStrDomInpObject
  : ItestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>
{
}

public interface ItestFieldGnrcPrntStrDomInp<TRef>
  // No Base because it's Class
{
  ItestFieldGnrcPrntStrDomInpObject<TRef>? As_FieldGnrcPrntStrDomInp { get; }
}

public interface ItestFieldGnrcPrntStrDomInpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntStrDomInp
  : IGqlpDomainString
{
}
