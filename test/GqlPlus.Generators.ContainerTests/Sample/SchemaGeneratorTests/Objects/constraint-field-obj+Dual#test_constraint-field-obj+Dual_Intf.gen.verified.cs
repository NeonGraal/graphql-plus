//HintName: test_constraint-field-obj+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

public interface ItestCnstFieldObjDual
  : ItestRefCnstFieldObjDual<ItestAltCnstFieldObjDual>
{
  ItestCnstFieldObjDualObject AsCnstFieldObjDual { get; }
}

public interface ItestCnstFieldObjDualObject
  : ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>
{
}

public interface ItestRefCnstFieldObjDual<TRef>
  : IGqlpModelImplementationBase
{
  ItestRefCnstFieldObjDualObject<TRef> AsRefCnstFieldObjDual { get; }
}

public interface ItestRefCnstFieldObjDualObject<TRef>
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldObjDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestPrntCnstFieldObjDualObject AsPrntCnstFieldObjDual { get; }
}

public interface ItestPrntCnstFieldObjDualObject
{
}

public interface ItestAltCnstFieldObjDual
  : ItestPrntCnstFieldObjDual
{
  ItestAltCnstFieldObjDualObject AsAltCnstFieldObjDual { get; }
}

public interface ItestAltCnstFieldObjDualObject
  : ItestPrntCnstFieldObjDualObject
{
  decimal Alt { get; }
}
