//HintName: test_object-field+Dual_Intf.gen.cs
// Generated from object-field+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Dual;

public interface ItestObjFieldDual
{
  public ItestObjFieldDualObject AsObjFieldDual { get; set; }
}

public interface ItestObjFieldDualObject
{
  public ItestFldObjFieldDual Field { get; set; }
}

public interface ItestFldObjFieldDual
{
  public ItestFldObjFieldDualObject AsFldObjFieldDual { get; set; }
}

public interface ItestFldObjFieldDualObject
{
}
