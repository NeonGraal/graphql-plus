//HintName: test_generic-alt-mod-String+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-String+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_String_Output;

public interface ItestRefGnrcAltModStrOutp<TRef>
  : IGqlpModelImplementationBase
{
  IDictionary<string, TRef> Asref { get; }
  ItestRefGnrcAltModStrOutpObject<TRef> AsRefGnrcAltModStrOutp { get; }
}

public interface ItestRefGnrcAltModStrOutpObject<TRef>
{
}
