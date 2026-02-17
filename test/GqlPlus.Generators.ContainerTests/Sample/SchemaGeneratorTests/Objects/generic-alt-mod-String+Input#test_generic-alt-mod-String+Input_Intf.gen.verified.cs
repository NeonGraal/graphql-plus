//HintName: test_generic-alt-mod-String+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-String+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_String_Input;

public interface ItestRefGnrcAltModStrInp<TRef>
  : IGqlpModelImplementationBase
{
  IDictionary<string, TRef>? Asref { get; }
  ItestRefGnrcAltModStrInpObject<TRef>? As_RefGnrcAltModStrInp { get; }
}

public interface ItestRefGnrcAltModStrInpObject<TRef>
  : IGqlpModelImplementationBase
{
}
