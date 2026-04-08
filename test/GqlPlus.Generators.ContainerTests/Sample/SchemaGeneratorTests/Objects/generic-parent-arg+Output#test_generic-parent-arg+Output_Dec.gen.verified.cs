//HintName: test_generic-parent-arg+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Output;

public interface ItestGnrcPrntArgOutp<TType>
  : ItestRefGnrcPrntArgOutp<TType>
{
  ItestGnrcPrntArgOutpObject<TType>? As_GnrcPrntArgOutp { get; }
}

public interface ItestGnrcPrntArgOutpObject<TType>
  : ItestRefGnrcPrntArgOutpObject<TType>
{
}

public interface ItestRefGnrcPrntArgOutp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcPrntArgOutpObject<TRef>? As_RefGnrcPrntArgOutp { get; }
}

public interface ItestRefGnrcPrntArgOutpObject<TRef>
  // No Base because it's Class
{
}
