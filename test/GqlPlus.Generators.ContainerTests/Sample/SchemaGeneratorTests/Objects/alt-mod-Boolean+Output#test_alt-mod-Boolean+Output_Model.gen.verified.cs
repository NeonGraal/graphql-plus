//HintName: test_alt-mod-Boolean+Output_Model.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Output;

public class testAltModBoolOutp
  : GqlpModelBase
  , ItestAltModBoolOutp
{
  public IDictionary<bool, ItestAltAltModBoolOutp>? AsAltAltModBoolOutp { get; set; }
  public ItestAltModBoolOutpObject? As_AltModBoolOutp { get; set; }
}

public class testAltModBoolOutpObject
  : GqlpModelBase
  , ItestAltModBoolOutpObject
{

  public testAltModBoolOutpObject
    ()
  {
  }
}

public class testAltAltModBoolOutp
  : GqlpModelBase
  , ItestAltAltModBoolOutp
{
  public string? AsString { get; set; }
  public ItestAltAltModBoolOutpObject? As_AltAltModBoolOutp { get; set; }
}

public class testAltAltModBoolOutpObject
  : GqlpModelBase
  , ItestAltAltModBoolOutpObject
{
  public decimal Alt { get; set; }

  public testAltAltModBoolOutpObject
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
