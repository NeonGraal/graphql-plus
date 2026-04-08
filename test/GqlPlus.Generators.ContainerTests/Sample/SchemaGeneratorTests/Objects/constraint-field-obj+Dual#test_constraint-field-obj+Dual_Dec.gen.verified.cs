//HintName: test_constraint-field-obj+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

public interface ItestCnstFieldObjDual
  : ItestRefCnstFieldObjDual<ItestAltCnstFieldObjDual>
{
  ItestCnstFieldObjDualObject? As_CnstFieldObjDual { get; }
}

public interface ItestCnstFieldObjDualObject
  : ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>
{
}

public interface ItestRefCnstFieldObjDual<TRef>
  // No Base because it's Class
{
  ItestRefCnstFieldObjDualObject<TRef>? As_RefCnstFieldObjDual { get; }
}

public interface ItestRefCnstFieldObjDualObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldObjDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstFieldObjDualObject? As_PrntCnstFieldObjDual { get; }
}

public interface ItestPrntCnstFieldObjDualObject
  // No Base because it's Class
{
}

public interface ItestAltCnstFieldObjDual
  : ItestPrntCnstFieldObjDual
{
  ItestAltCnstFieldObjDualObject? As_AltCnstFieldObjDual { get; }
}

public interface ItestAltCnstFieldObjDualObject
  : ItestPrntCnstFieldObjDualObject
{
  decimal Alt { get; }
}
