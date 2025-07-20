//HintName: Model_field-mod-param+Dual.gen.cs
// Generated from field-mod-param+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_field_mod_param_Dual;

public interface IFieldModParamDual<Tmod>
{
  FldFieldModParamDual field { get; }
}
public class DualFieldModParamDual<Tmod>
  : IFieldModParamDual<Tmod>
{
  public FldFieldModParamDual field { get; set; }
}

public interface IFldFieldModParamDual
{
  Number field { get; }
  String AsString { get; }
}
public class DualFldFieldModParamDual
  : IFldFieldModParamDual
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
