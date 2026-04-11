//HintName: test_alt-mod-Boolean+Input_Model.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Input;

public class testAltModBoolInp
  : GqlpModelBase
  , ItestAltModBoolInp
{
  public IDictionary<bool, ItestAltAltModBoolInp>? AsAltAltModBoolInp { get; set; }
  public ItestAltModBoolInpObject? As_AltModBoolInp { get; set; }
}

public class testAltModBoolInpObject
  : GqlpModelBase
  , ItestAltModBoolInpObject
{

  public testAltModBoolInpObject
    ()
  {
  }
}

public class testAltAltModBoolInp
  : GqlpModelBase
  , ItestAltAltModBoolInp
{
  public string? AsString { get; set; }
  public ItestAltAltModBoolInpObject? As_AltAltModBoolInp { get; set; }
}

public class testAltAltModBoolInpObject
  : GqlpModelBase
  , ItestAltAltModBoolInpObject
{
  public decimal Alt { get; set; }

  public testAltAltModBoolInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
