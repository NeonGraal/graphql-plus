//HintName: test_object-field-alias+Dual_Intf.gen.cs
// Generated from object-field-alias+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Dual;

public interface ItestObjFieldAliasDual
{
  ItestObjFieldAliasDualObject AsObjFieldAliasDual { get; }
}

public interface ItestObjFieldAliasDualObject
{
  ItestFldObjFieldAliasDual Field { get; }
}

public interface ItestFldObjFieldAliasDual
{
  ItestFldObjFieldAliasDualObject AsFldObjFieldAliasDual { get; }
}

public interface ItestFldObjFieldAliasDualObject
{
}
