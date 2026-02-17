//HintName: test_alt-mod-param+Output_Impl.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

public class testAltModParamOutp<TMod>
  : GqlpModelImplementationBase
  , ItestAltModParamOutp<TMod>
{
  public IDictionary<TMod, ItestAltAltModParamOutp>? AsAltAltModParamOutp { get; set; }
  public ItestAltModParamOutpObject<TMod>? As_AltModParamOutp { get; set; }
}

public class testAltModParamOutpObject<TMod>
  : GqlpModelImplementationBase
  , ItestAltModParamOutpObject<TMod>
{

  public testAltModParamOutpObject()
  {
  }
}

public class testAltAltModParamOutp
  : GqlpModelImplementationBase
  , ItestAltAltModParamOutp
{
  public string? AsString { get; set; }
  public ItestAltAltModParamOutpObject? As_AltAltModParamOutp { get; set; }
}

public class testAltAltModParamOutpObject
  : GqlpModelImplementationBase
  , ItestAltAltModParamOutpObject
{
  public decimal Alt { get; set; }

  public testAltAltModParamOutpObject(decimal alt)
  {
    Alt = alt;
  }
}
