//HintName: test_object-field+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-field+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Dual;

public interface ItestObjFieldDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldDualObject AsObjFieldDual { get; }
}

public interface ItestObjFieldDualObject
{
  ItestFldObjFieldDual Field { get; }
}

public interface ItestFldObjFieldDual
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldDualObject AsFldObjFieldDual { get; }
}

public interface ItestFldObjFieldDualObject
{
}
