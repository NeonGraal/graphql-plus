﻿//HintName: Model_Intro_Object.gen.cs
// Generated from Intro_Object.graphql+
/*
output _TypeObject<$kind $parent $field $alternate> {
    : _ChildType<$kind $parent>
        typeParams: _Described[]
        fields: $field[]
        alternates: $alternate[]
        allFields: _ObjectFor<$field>[]
        allAlternates: _ObjectFor<$alternate>[]
    }
dual _ObjDescribed<$base> {
        base: $base
        description: String
    | $base
    }
output _ObjType<$base> {
    | _BaseType<_TypeKind.Internal>
    | _TypeSimple
    | $base
    }
output _ObjBase {
        typeArgs: _ObjDescribed<_ObjArg>[]
    | _TypeParam
    }
output _ObjArg {
    : _TypeRef<_TypeKind>
    | _TypeParam
}
domain _TypeParam { :_Identifier String }
output _Alternate<$base> {
      type: _ObjDescribed<$base>
      collections: _Collections[]
    }
output _ObjectFor<$for> {
    : $for
        object: _Identifier
    }
output _Field<$base> {
    : _Aliased
      type: _ObjDescribed<$base>
      modifiers: _Modifiers[]
    }
*/
namespace GqlPlus;
public class Model_Intro_Object {}