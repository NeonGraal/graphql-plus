//HintName: test_generic-field+Output_Intf.gen.cs
// Generated from generic-field+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Output;

public interface ItestGnrcFieldOutp<TType>
{
  ItestGnrcFieldOutpObject AsGnrcFieldOutp { get; }
}

public interface ItestGnrcFieldOutpObject<TType>
{
  TType Field { get; }
}
