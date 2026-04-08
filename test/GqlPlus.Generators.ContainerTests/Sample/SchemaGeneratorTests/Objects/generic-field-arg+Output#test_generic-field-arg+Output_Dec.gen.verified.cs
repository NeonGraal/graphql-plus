//HintName: test_generic-field-arg+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Output;

public interface ItestGnrcFieldArgOutp<TType>
  // No Base because it's Class
{
  ItestGnrcFieldArgOutpObject<TType>? As_GnrcFieldArgOutp { get; }
}

public interface ItestGnrcFieldArgOutpObject<TType>
  // No Base because it's Class
{
  ItestRefGnrcFieldArgOutp<TType> Field { get; }
}

public interface ItestRefGnrcFieldArgOutp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcFieldArgOutpObject<TRef>? As_RefGnrcFieldArgOutp { get; }
}

public interface ItestRefGnrcFieldArgOutpObject<TRef>
  // No Base because it's Class
{
}
