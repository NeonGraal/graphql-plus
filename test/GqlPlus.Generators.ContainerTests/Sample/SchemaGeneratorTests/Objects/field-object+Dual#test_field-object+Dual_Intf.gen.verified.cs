//HintName: test_field-object+Dual_Intf.gen.cs
// Generated from field-object+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

public interface ItestFieldObjDual
{
  ItestFieldObjDualObject AsFieldObjDual { get; }
}

public interface ItestFieldObjDualObject
{
  ItestFldFieldObjDual Field { get; }
}

public interface ItestFldFieldObjDual
{
  string AsString { get; }
  ItestFldFieldObjDualObject AsFldFieldObjDual { get; }
}

public interface ItestFldFieldObjDualObject
{
  decimal Field { get; }
}
