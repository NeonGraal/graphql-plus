//HintName: test_generic-field+Output_Impl.gen.cs
// Generated from generic-field+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Output;

public class testGnrcFieldOutp<TType>
  : ItestGnrcFieldOutp<TType>
{
  public TType Field { get; set; }
  public ItestGnrcFieldOutpObject<TType> AsGnrcFieldOutp { get; set; }
}
