//HintName: test_generic-alt-arg-descr+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Output;

public interface ItestGnrcAltArgDescrOutp<TType>
  // No Base because it's Class
{
  ItestRefGnrcAltArgDescrOutp<TType>? AsRefGnrcAltArgDescrOutp { get; }
  ItestGnrcAltArgDescrOutpObject<TType>? As_GnrcAltArgDescrOutp { get; }
}

public interface ItestGnrcAltArgDescrOutpObject<TType>
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltArgDescrOutp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgDescrOutpObject<TRef>? As_RefGnrcAltArgDescrOutp { get; }
}

public interface ItestRefGnrcAltArgDescrOutpObject<TRef>
  // No Base because it's Class
{
}
