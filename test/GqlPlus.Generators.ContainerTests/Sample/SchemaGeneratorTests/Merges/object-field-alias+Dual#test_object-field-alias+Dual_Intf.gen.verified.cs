//HintName: test_object-field-alias+Dual_Intf.gen.cs
// Generated from object-field-alias+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Dual;

public interface ItestObjFieldAliasDual
{
  public ItestObjFieldAliasDualObject AsObjFieldAliasDual { get; set; }
}

public interface ItestObjFieldAliasDualObject
{
  public ItestFldObjFieldAliasDual Field { get; set; }
}

public interface ItestFldObjFieldAliasDual
{
  public ItestFldObjFieldAliasDualObject AsFldObjFieldAliasDual { get; set; }
}

public interface ItestFldObjFieldAliasDualObject
{
}
