//HintName: Model_field-mod-param+Input.gen.cs
// Generated from field-mod-param+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_field_mod_param_Input;

public interface IFieldModParamInp<Tmod>
{
  FldFieldModParamInp field { get; }
}
public class InputFieldModParamInp<Tmod>
  : IFieldModParamInp<Tmod>
{
  public FldFieldModParamInp field { get; set; }
}

public interface IFldFieldModParamInp
{
  Number field { get; }
  String AsString { get; }
}
public class InputFldFieldModParamInp
  : IFldFieldModParamInp
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
