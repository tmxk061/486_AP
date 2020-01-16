using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("startWidth", "endWidth", "widthMultiplier", "numCornerVertices", "numCapVertices", "useWorldSpace", "loop", "startColor", "endColor", "positionCount", "shadowBias", "generateLightingData", "textureMode", "alignment", "widthCurve", "colorGradient", "enabled", "shadowCastingMode", "receiveShadows", "motionVectorGenerationMode", "lightProbeUsage", "reflectionProbeUsage", "renderingLayerMask", "rendererPriority", "sortingLayerName", "sortingLayerID", "sortingOrder", "sortingGroupID", "sortingGroupOrder", "allowOcclusionWhenDynamic", "staticBatchRootTransform", "lightProbeProxyVolumeOverride", "probeAnchor", "lightmapIndex", "realtimeLightmapIndex", "lightmapScaleOffset", "realtimeLightmapScaleOffset", "materials", "material", "sharedMaterial", "sharedMaterials", "hideFlags")]
	public class ES3Type_LineRenderer : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_LineRenderer() : base(typeof(UnityEngine.LineRenderer))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.LineRenderer)obj;
			
			writer.WriteProperty("startWidth", instance.startWidth, ES3Type_float.Instance);
			writer.WriteProperty("endWidth", instance.endWidth, ES3Type_float.Instance);
			writer.WriteProperty("widthMultiplier", instance.widthMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("numCornerVertices", instance.numCornerVertices, ES3Type_int.Instance);
			writer.WriteProperty("numCapVertices", instance.numCapVertices, ES3Type_int.Instance);
			writer.WriteProperty("useWorldSpace", instance.useWorldSpace, ES3Type_bool.Instance);
			writer.WriteProperty("loop", instance.loop, ES3Type_bool.Instance);
			writer.WriteProperty("startColor", instance.startColor, ES3Type_Color.Instance);
			writer.WriteProperty("endColor", instance.endColor, ES3Type_Color.Instance);
			writer.WriteProperty("positionCount", instance.positionCount, ES3Type_int.Instance);
			writer.WriteProperty("shadowBias", instance.shadowBias, ES3Type_float.Instance);
			writer.WriteProperty("generateLightingData", instance.generateLightingData, ES3Type_bool.Instance);
			writer.WriteProperty("textureMode", instance.textureMode);
			writer.WriteProperty("alignment", instance.alignment);
			writer.WriteProperty("widthCurve", instance.widthCurve, ES3Type_AnimationCurve.Instance);
			writer.WriteProperty("colorGradient", instance.colorGradient, ES3Type_Gradient.Instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("shadowCastingMode", instance.shadowCastingMode, ES3Type_enum.Instance);
			writer.WriteProperty("receiveShadows", instance.receiveShadows, ES3Type_bool.Instance);
			writer.WriteProperty("motionVectorGenerationMode", instance.motionVectorGenerationMode, ES3Type_enum.Instance);
			writer.WriteProperty("lightProbeUsage", instance.lightProbeUsage, ES3Type_enum.Instance);
			writer.WriteProperty("reflectionProbeUsage", instance.reflectionProbeUsage, ES3Type_enum.Instance);
			writer.WriteProperty("renderingLayerMask", instance.renderingLayerMask, ES3Type_uint.Instance);
			writer.WriteProperty("rendererPriority", instance.rendererPriority, ES3Type_int.Instance);
			writer.WriteProperty("sortingLayerName", instance.sortingLayerName, ES3Type_string.Instance);
			writer.WriteProperty("sortingLayerID", instance.sortingLayerID, ES3Type_int.Instance);
			writer.WriteProperty("sortingOrder", instance.sortingOrder, ES3Type_int.Instance);
			writer.WritePrivateProperty("sortingGroupID", instance);
			writer.WritePrivateProperty("sortingGroupOrder", instance);
			writer.WriteProperty("allowOcclusionWhenDynamic", instance.allowOcclusionWhenDynamic, ES3Type_bool.Instance);
			writer.WritePrivatePropertyByRef("staticBatchRootTransform", instance);
			writer.WritePropertyByRef("lightProbeProxyVolumeOverride", instance.lightProbeProxyVolumeOverride);
			writer.WritePropertyByRef("probeAnchor", instance.probeAnchor);
			writer.WriteProperty("lightmapIndex", instance.lightmapIndex, ES3Type_int.Instance);
			writer.WriteProperty("realtimeLightmapIndex", instance.realtimeLightmapIndex, ES3Type_int.Instance);
			writer.WriteProperty("lightmapScaleOffset", instance.lightmapScaleOffset, ES3Type_Vector4.Instance);
			writer.WriteProperty("realtimeLightmapScaleOffset", instance.realtimeLightmapScaleOffset, ES3Type_Vector4.Instance);
			writer.WriteProperty("materials", instance.materials, ES3Type_MaterialArray.Instance);
			writer.WritePropertyByRef("material", instance.material);
			writer.WritePropertyByRef("sharedMaterial", instance.sharedMaterial);
			writer.WriteProperty("sharedMaterials", instance.sharedMaterials, ES3Type_MaterialArray.Instance);
			writer.WriteProperty("hideFlags", instance.hideFlags, ES3Type_enum.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.LineRenderer)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "startWidth":
						instance.startWidth = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "endWidth":
						instance.endWidth = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "widthMultiplier":
						instance.widthMultiplier = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "numCornerVertices":
						instance.numCornerVertices = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "numCapVertices":
						instance.numCapVertices = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "useWorldSpace":
						instance.useWorldSpace = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "loop":
						instance.loop = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "startColor":
						instance.startColor = reader.Read<UnityEngine.Color>(ES3Type_Color.Instance);
						break;
					case "endColor":
						instance.endColor = reader.Read<UnityEngine.Color>(ES3Type_Color.Instance);
						break;
					case "positionCount":
						instance.positionCount = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "shadowBias":
						instance.shadowBias = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "generateLightingData":
						instance.generateLightingData = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "textureMode":
						instance.textureMode = reader.Read<UnityEngine.LineTextureMode>();
						break;
					case "alignment":
						instance.alignment = reader.Read<UnityEngine.LineAlignment>();
						break;
					case "widthCurve":
						instance.widthCurve = reader.Read<UnityEngine.AnimationCurve>(ES3Type_AnimationCurve.Instance);
						break;
					case "colorGradient":
						instance.colorGradient = reader.Read<UnityEngine.Gradient>(ES3Type_Gradient.Instance);
						break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "shadowCastingMode":
						instance.shadowCastingMode = reader.Read<UnityEngine.Rendering.ShadowCastingMode>(ES3Type_enum.Instance);
						break;
					case "receiveShadows":
						instance.receiveShadows = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "motionVectorGenerationMode":
						instance.motionVectorGenerationMode = reader.Read<UnityEngine.MotionVectorGenerationMode>(ES3Type_enum.Instance);
						break;
					case "lightProbeUsage":
						instance.lightProbeUsage = reader.Read<UnityEngine.Rendering.LightProbeUsage>(ES3Type_enum.Instance);
						break;
					case "reflectionProbeUsage":
						instance.reflectionProbeUsage = reader.Read<UnityEngine.Rendering.ReflectionProbeUsage>(ES3Type_enum.Instance);
						break;
					case "renderingLayerMask":
						instance.renderingLayerMask = reader.Read<System.UInt32>(ES3Type_uint.Instance);
						break;
					case "rendererPriority":
						instance.rendererPriority = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "sortingLayerName":
						instance.sortingLayerName = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "sortingLayerID":
						instance.sortingLayerID = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "sortingOrder":
						instance.sortingOrder = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "sortingGroupID":
					reader.SetPrivateProperty("sortingGroupID", reader.Read<System.Int32>(), instance);
					break;
					case "sortingGroupOrder":
					reader.SetPrivateProperty("sortingGroupOrder", reader.Read<System.Int32>(), instance);
					break;
					case "allowOcclusionWhenDynamic":
						instance.allowOcclusionWhenDynamic = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "staticBatchRootTransform":
					reader.SetPrivateProperty("staticBatchRootTransform", reader.Read<UnityEngine.Transform>(), instance);
					break;
					case "lightProbeProxyVolumeOverride":
						instance.lightProbeProxyVolumeOverride = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "probeAnchor":
						instance.probeAnchor = reader.Read<UnityEngine.Transform>(ES3Type_Transform.Instance);
						break;
					case "lightmapIndex":
						instance.lightmapIndex = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "realtimeLightmapIndex":
						instance.realtimeLightmapIndex = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "lightmapScaleOffset":
						instance.lightmapScaleOffset = reader.Read<UnityEngine.Vector4>(ES3Type_Vector4.Instance);
						break;
					case "realtimeLightmapScaleOffset":
						instance.realtimeLightmapScaleOffset = reader.Read<UnityEngine.Vector4>(ES3Type_Vector4.Instance);
						break;
					case "materials":
						instance.materials = reader.Read<UnityEngine.Material[]>(ES3Type_MaterialArray.Instance);
						break;
					case "material":
						instance.material = reader.Read<UnityEngine.Material>(ES3Type_Material.Instance);
						break;
					case "sharedMaterial":
						instance.sharedMaterial = reader.Read<UnityEngine.Material>(ES3Type_Material.Instance);
						break;
					case "sharedMaterials":
						instance.sharedMaterials = reader.Read<UnityEngine.Material[]>(ES3Type_MaterialArray.Instance);
						break;
					case "hideFlags":
						instance.hideFlags = reader.Read<UnityEngine.HideFlags>(ES3Type_enum.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_LineRendererArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_LineRendererArray() : base(typeof(UnityEngine.LineRenderer[]), ES3Type_LineRenderer.Instance)
		{
			Instance = this;
		}
	}
}