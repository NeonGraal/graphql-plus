//HintName: test_generic-alt+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_Output;

public class testGnrcAltOutp<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltOutp<TType>
{
  public TType? Astype { get; set; }
  public ItestGnrcAltOutpObject<TType>? As_GnrcAltOutp { get; set; }
}

public class testGnrcAltOutpObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltOutpObject<TType>
{
}
