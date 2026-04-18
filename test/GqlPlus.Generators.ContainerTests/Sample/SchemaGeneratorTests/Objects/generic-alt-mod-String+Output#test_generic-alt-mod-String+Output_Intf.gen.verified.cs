//HintName: test_generic-alt-mod-String+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-String+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_String_Output;

public interface ItestRefGnrcAltModStrOutp<TRef>
  : IGqlpInterfaceBase
{
  IDictionary<string, TRef>? Asref { get; }
  ItestRefGnrcAltModStrOutpObject<TRef>? As_RefGnrcAltModStrOutp { get; }
}

public interface ItestRefGnrcAltModStrOutpObject<TRef>
  : IGqlpInterfaceBase
{
}
