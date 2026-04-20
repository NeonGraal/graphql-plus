//HintName: test_field-mod-param+Output_Model.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

public class testFieldModParamOutp<TMod>
  : GqlpModelBase
  , ItestFieldModParamOutp<TMod>
{
  public ItestFieldModParamOutpObject<TMod>? As_FieldModParamOutp { get; set; }
}

public class testFieldModParamOutpObject<TMod>
  : GqlpModelBase
  , ItestFieldModParamOutpObject<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamOutp> Field { get; set; }

  public testFieldModParamOutpObject
    ( IDictionary<TMod, ItestFldFieldModParamOutp> pfield
    )
  {
    Field = pfield;
  }
}

public class testFldFieldModParamOutp
  : GqlpModelBase
  , ItestFldFieldModParamOutp
{
  public string? AsString { get; set; }
  public ItestFldFieldModParamOutpObject? As_FldFieldModParamOutp { get; set; }
}

public class testFldFieldModParamOutpObject
  : GqlpModelBase
  , ItestFldFieldModParamOutpObject
{
  public decimal Field { get; set; }

  public testFldFieldModParamOutpObject
    ( decimal pfield
    )
  {
    Field = pfield;
  }
}
