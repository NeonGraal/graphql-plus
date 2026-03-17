//HintName: test_generic-alt-simple+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

public class testGnrcAltSmplOutp
  : GqlpModelImplementationBase
  , ItestGnrcAltSmplOutp
{
  public ItestRefGnrcAltSmplOutp<string>? AsRefGnrcAltSmplOutp { get; set; }
  public ItestGnrcAltSmplOutpObject? As_GnrcAltSmplOutp { get; set; }
}

public class testGnrcAltSmplOutpObject
  : GqlpModelImplementationBase
  , ItestGnrcAltSmplOutpObject
{
}

public class testRefGnrcAltSmplOutp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltSmplOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltSmplOutpObject<TRef>? As_RefGnrcAltSmplOutp { get; set; }
}

public class testRefGnrcAltSmplOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltSmplOutpObject<TRef>
{
}
