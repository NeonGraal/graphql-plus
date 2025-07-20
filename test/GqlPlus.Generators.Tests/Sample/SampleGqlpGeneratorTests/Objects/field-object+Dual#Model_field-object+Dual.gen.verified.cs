//HintName: Model_field-object+Dual.gen.cs
// Generated from field-object+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_field_object_Dual;

public interface IFieldObjDual
{
  FldFieldObjDual field { get; }
}
public class DualFieldObjDual
  : IFieldObjDual
{
  public FldFieldObjDual field { get; set; }
}

public interface IFldFieldObjDual
{
  Number field { get; }
  String AsString { get; }
}
public class DualFldFieldObjDual
  : IFldFieldObjDual
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
