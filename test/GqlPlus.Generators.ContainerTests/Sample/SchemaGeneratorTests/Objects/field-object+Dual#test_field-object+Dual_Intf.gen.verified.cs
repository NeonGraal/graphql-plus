//HintName: test_field-object+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-object+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

public interface ItestFieldObjDual
  : IGqlpModelImplementationBase
{
  ItestFieldObjDualObject AsFieldObjDual { get; }
}

public interface ItestFieldObjDualObject
{
  ItestFldFieldObjDual Field { get; }
}

public interface ItestFldFieldObjDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestFldFieldObjDualObject AsFldFieldObjDual { get; }
}

public interface ItestFldFieldObjDualObject
{
  decimal Field { get; }
}
