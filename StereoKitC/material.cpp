#include "material.h"

material_t material_create(shader_t shader, tex2d_t tex) {
	material_t result = (material_t)assets_allocate(asset_type_material);
	assets_addref(shader->header);
	assets_addref(tex->header);
	result->shader  = shader;
	result->texture = tex;
	return result;
}
void material_release(material_t material) {
	assets_releaseref(material->header);
}
void material_destroy(material_t material) {
	shader_release(material->shader);
	tex2d_release(material->texture);
	*material = {};
}