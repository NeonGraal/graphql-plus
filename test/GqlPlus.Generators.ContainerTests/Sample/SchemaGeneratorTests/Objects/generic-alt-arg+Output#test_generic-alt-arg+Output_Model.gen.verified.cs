//HintName: test_generic-alt-arg+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Output;

public class testGnrcAltArgOutp<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltArgOutp<TType>
{
  public ItestRefGnrcAltArgOutp<TType>? AsRefGnrcAltArgOutp { get; set; }
  public ItestGnrcAltArgOutpObject<TType>? As_GnrcAltArgOutp { get; set; }
}

public class testGnrcAltArgOutpObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltArgOutpObject<TType>
{
}

public class testRefGnrcAltArgOutp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltArgOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgOutpObject<TRef>? As_RefGnrcAltArgOutp { get; set; }
}

public class testRefGnrcAltArgOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltArgOutpObject<TRef>
{
}
