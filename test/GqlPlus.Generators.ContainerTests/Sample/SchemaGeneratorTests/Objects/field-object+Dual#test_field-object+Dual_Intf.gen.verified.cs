//HintName: test_field-object+Dual_Intf.gen.cs
// Generated from field-object+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

public interface ItestFieldObjDual
{
  public ItestFieldObjDualObject AsFieldObjDual { get; set; }
}

public interface ItestFieldObjDualObject
{
  public ItestFldFieldObjDual Field { get; set; }
}

public interface ItestFldFieldObjDual
{
  public string AsString { get; set; }
  public ItestFldFieldObjDualObject AsFldFieldObjDual { get; set; }
}

public interface ItestFldFieldObjDualObject
{
  public decimal Field { get; set; }
}
