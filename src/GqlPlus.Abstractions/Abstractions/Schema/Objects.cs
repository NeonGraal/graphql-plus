namespace GqlPlus.Abstractions.Schema;

public interface IGqlpObject
  : IGqlpType<IGqlpObjBase>
{
  IEnumerable<IGqlpTypeParameter> TypeParameters { get; }
  IEnumerable<IGqlpObjField> Fields { get; }
  IEnumerable<IGqlpObjAlternate> Alternates { get; }
}

public interface IGqlpObject<TBase, TField, TAlt>
  : IGqlpObject
  where TBase : IGqlpObjBase
  where TField : IGqlpObjField
  where TAlt : IGqlpObjAlternate
{
  TBase? ObjParent { get; }
  IEnumerable<TField> ObjFields { get; }
  IEnumerable<TAlt> ObjAlternates { get; }
}

public interface IGqlpObjType
  : IGqlpAbbreviated
  , IGqlpDescribed
{
  string Label { get; }
  string TypeName { get; }
  string FullType { get; }
  bool IsTypeParameter { get; }
}

public interface IGqlpObjArgument
  : IGqlpObjType
  , IEquatable<IGqlpObjArgument>
{ }

public interface IGqlpObjBase
  : IGqlpObjType
  , IEquatable<IGqlpObjBase>
{
  IEnumerable<IGqlpObjArgument> Arguments { get; }
}

public interface IGqlpObjBase<TBase>
  : IGqlpObjBase
  where TBase : IGqlpObjArgument
{
  IEnumerable<TBase> BaseArguments { get; }
}

public interface IGqlpObjField
  : IGqlpAliased
  , IGqlpModifiers
{
  IGqlpObjBase Type { get; }
  string ModifiedType { get; }
}

public interface IGqlpObjField<TBase>
  : IGqlpObjField
  where TBase : IGqlpObjBase
{
  TBase BaseType { get; }
}

public interface IGqlpObjAlternate
  : IGqlpError
  , IGqlpDescribed
  , IGqlpModifiers
{
  IGqlpObjBase Type { get; }
}

public interface IGqlpObjAlternate<TBase>
  : IGqlpObjAlternate
  where TBase : IGqlpObjBase
{
  TBase BaseType { get; }
}

public interface IGqlpTypeParameter
  : IGqlpDescribed, IGqlpNamed
{ }

public interface IGqlpDualObject
  : IGqlpObject<IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>
{ }

public interface IGqlpDualArgument
  : IGqlpObjArgument
{
  string Dual { get; }
}

public interface IGqlpDualBase
  : IGqlpObjBase<IGqlpDualArgument>
{
  string Dual { get; }
}

public interface IGqlpDualField
  : IGqlpObjField<IGqlpDualBase>
{ }

public interface IGqlpDualAlternate
  : IGqlpObjAlternate<IGqlpDualBase>
{ }

public interface IGqlpToDual<T>
  where T : IGqlpObjType
{
  T ToDual { get; }
}

public interface IGqlpInputObject
  : IGqlpObject<IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>
{ }

public interface IGqlpInputArgument
  : IGqlpObjArgument
  , IGqlpToDual<IGqlpDualArgument>
{
  string Input { get; }
}

public interface IGqlpInputBase
  : IGqlpObjBase<IGqlpInputArgument>
  , IGqlpToDual<IGqlpDualBase>
{
  string Input { get; }
}

public interface IGqlpInputField
  : IGqlpObjField<IGqlpInputBase>
{
  IGqlpConstant? DefaultValue { get; }
}

public interface IGqlpInputAlternate
  : IGqlpObjAlternate<IGqlpInputBase>
{ }

public interface IGqlpOutputObject
  : IGqlpObject<IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>
{ }

public interface IGqlpOutputEnum
  : IGqlpError
{
  string TypeName { get; }
  string? EnumMember { get; }

  void SetEnumType(string enumType);
}

public interface IGqlpOutputArgument
  : IGqlpObjArgument
  , IGqlpOutputEnum
  , IGqlpToDual<IGqlpDualArgument>
{
  string Output { get; }
}

public interface IGqlpOutputBase
  : IGqlpObjBase<IGqlpOutputArgument>
  , IGqlpToDual<IGqlpDualBase>
{
  string Output { get; }
}

public interface IGqlpOutputField
  : IGqlpObjField<IGqlpOutputBase>
  , IGqlpOutputEnum
{
  IEnumerable<IGqlpInputParameter> Parameters { get; }
}

public interface IGqlpOutputAlternate
  : IGqlpObjAlternate<IGqlpOutputBase>
{ }

public interface IGqlpInputParameter
  : IGqlpError, IGqlpDescribed, IGqlpModifiers
{
  IGqlpInputBase Type { get; }
  IGqlpConstant? DefaultValue { get; }
}
